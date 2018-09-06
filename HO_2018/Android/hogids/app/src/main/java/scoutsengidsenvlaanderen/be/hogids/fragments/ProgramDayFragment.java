package scoutsengidsenvlaanderen.be.hogids.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import scoutsengidsenvlaanderen.be.hogids.LocalStorage;
import scoutsengidsenvlaanderen.be.hogids.R;
import scoutsengidsenvlaanderen.be.hogids.fragments.dummy.DummyContent;
import scoutsengidsenvlaanderen.be.hogids.fragments.dummy.DummyContent.DummyItem;

import java.util.List;

public class ProgramDayFragment extends Fragment {

    int hoDay = 0;
    /**
     * Mandatory empty constructor for the fragment manager to instantiate the
     * fragment (e.g. upon screen orientation changes).
     */
    public ProgramDayFragment() {
    }

    // TODO: Customize parameter initialization
    @SuppressWarnings("unused")
    public static ProgramDayFragment newInstance(int Day) {
        ProgramDayFragment fragment = new ProgramDayFragment();
        fragment.hoDay = Day;
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_programdayfragment_list, container, false);

        // Set the adapter
        if (view instanceof RecyclerView) {
            Context context = view.getContext();
            RecyclerView recyclerView = (RecyclerView) view;
                recyclerView.setLayoutManager(new LinearLayoutManager(context));

            recyclerView.setAdapter(new ProgramDayFragmentRecyclerViewAdapter(LocalStorage.getInstance().getProgramItems(hoDay)));
        }
        return view;
    }


    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
    }

    @Override
    public void onDetach() {
        super.onDetach();
    }
}
